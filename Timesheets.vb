Imports System.Data.SQLite

Public Module Timesheet

	''' <summary>
	''' Returns a list of years stored in the database.
	''' </summary>
	''' <returns></returns>
	Public Function GetYears() As List(Of Integer)

		Dim cmd As New SQLiteCommand
		cmd.CommandText =
"SELECT DISTINCT Date
FROM TimeEntries
ORDER BY Date;"

		Dim yTable As DataTable = Database.ExecuteReader(cmd)
		Dim yearList As New List(Of Integer)

		If yTable IsNot Nothing AndAlso yTable.Rows.Count > 0 Then
			For i = 0 To yTable.Rows.Count - 1
				Dim year As Integer = GetYear(yTable.Rows(i).Item("Date"))
				If Not yearList.Contains(year) Then yearList.Add(year)
			Next
		End If

		Return yearList
	End Function


	Public Function GetYear(tDate As Date) As Integer
		Dim firstDayOfYear As Date = GetFirstDayOfWorkWeek(tDate)
		Return firstDayOfYear.Year
	End Function

	''' <summary>
	''' Returns a list of week numbers which have an entry in the database for the specified year.
	''' </summary>
	''' <param name="Year"></param>
	''' <returns></returns>
	Public Function GetWeeks(Year As Integer) As List(Of Integer)

		Dim cmd As New SQLiteCommand
		cmd.CommandText =
$"SELECT DISTINCT Date
FROM TimeEntries
WHERE strftime('%Y', Date) = @Year
ORDER BY Date;"
		cmd.Parameters.AddWithValue("@Year", Year.ToString)

		Dim wTable As DataTable = Database.ExecuteReader(cmd)
		Dim weekList As New List(Of Integer)
		Dim weekStart As DayOfWeek = Config.Properties.WeekStartDay

		If wTable IsNot Nothing AndAlso wTable.Rows.Count > 0 Then
			For i = 0 To wTable.Rows.Count - 1
				Dim weekNumber As Integer = GetWeekNumber(wTable.Rows(i).Item("Date"), weekStart)
				If weekNumber = 0 Then Continue For 'partial week from last year... already present
				If Not weekList.Contains(weekNumber) Then weekList.Add(weekNumber)
			Next
		End If

		Return weekList
	End Function

	''' <summary>
	''' Returns the week number of the specified date, using the specified start day of the week.
	''' </summary>
	''' <param name="tDate"></param>
	''' <param name="startDay"></param>
	''' <returns></returns>
	''' <remarks>Week 1 is the first full week of the year. Partial weeks fall at the end of the year, therefore a few days at the beginning of the year can still be the last week of the year prior. <br></br>If <strong>tDate</strong> is within this range, this function returns 0.</remarks>
	Public Function GetWeekNumber(tDate As Date, weekStart As DayOfWeek) As Integer

		Dim firstDayOfYear As Date = GetFirstDayOfWorkWeek(tDate.Year, 1, weekStart)
		Dim weekNumber As Integer = 0

		While firstDayOfYear <= tDate
			firstDayOfYear = firstDayOfYear.AddDays(7)
			weekNumber += 1
		End While


		Return weekNumber
	End Function

	''' <summary>
	''' Returns a list of timesheet entries for the entire work week containing the day specified. Any day within the week beginning on the configured week start day can be supplied to return the entries for the entire week.
	''' </summary>
	''' <returns></returns>
	Public Function GetWorkWeekEntries(year As Integer, weeknum As Integer) As List(Of TimesheetEntry)
		Return GetWorkWeekEntries(GetFirstDayOfWorkWeek(year, weeknum, Config.Properties.WeekStartDay))
	End Function

	''' <summary>
	''' Returns a list of timesheet entries for the entire work week containing the day specified. Any day within the week beginning on the configured week start day can be supplied to return the entries for the entire week.
	''' </summary>
	''' <param name="Workday"></param>
	''' <returns></returns>
	Public Function GetWorkWeekEntries(Workday As Date) As List(Of TimesheetEntry)
		Dim weekStartDate As Date = LastOccurenceDay(Workday, Config.Properties.WeekStartDay)
		Dim weekEndDate As Date = weekStartDate.AddDays(6)

		Dim cmd As New SQLiteCommand
		cmd.CommandText =
"SELECT *
FROM TimeEntries
WHERE Date BETWEEN @StartDate AND @EndDate;"
		cmd.Parameters.AddWithValue("@StartDate", weekStartDate.ToString("yyyy-MM-dd"))
		cmd.Parameters.AddWithValue("@EndDate", weekEndDate.ToString("yyyy-MM-dd"))

		Dim entryTable As DataTable = Database.ExecuteReader(cmd)
		Dim entryList As New List(Of TimesheetEntry)

		If entryTable IsNot Nothing AndAlso entryTable.Rows.Count > 0 Then
			For Each row As DataRow In entryTable.Rows
				entryList.Add(New TimesheetEntry(row.Item("Date"), row.Item("StartTime"), row.Item("EndTime"), row.Item("Comment").ToString, row.Item("ChargeCode").ToString, row.Item("ID")))
			Next
		End If

		Return entryList

	End Function

	''' <summary>
	''' Returns the first day of the work week specified by the year and week number.
	''' </summary>
	''' <param name="year"></param>
	''' <param name="weeknum"></param>
	''' <returns></returns>
	Public Function GetFirstDayOfWorkWeek(year As Integer, weeknum As Integer, weekStart As DayOfWeek) As Date

		Dim targetDate As Date = Nothing

		For i = 1 To 8
			If DateSerial(year, 1, i).DayOfWeek = weekStart Then
				targetDate = DateSerial(year, 1, i)
				Exit For
			End If
		Next

		If targetDate = Nothing Then
			Throw New Exception("TargetDate was nothing.")
		End If

		targetDate = targetDate.AddDays(7 * (weeknum - 1))
		Return targetDate
	End Function
	''' <summary>
	''' Returns the first day of the work week specified by the year and week number.
	''' </summary>
	''' <param name="year"></param>
	''' <param name="weeknum"></param>
	''' <returns></returns>
	Public Function GetFirstDayOfWorkWeek(tdate As Date) As Date
		Dim weekStart As DayOfWeek = Config.Properties.WeekStartDay
		Dim targetDate As Date = Nothing

		For i = 0 To -7 Step -1
			If tdate.AddDays(i).DayOfWeek = weekStart Then
				targetDate = tdate.AddDays(i)
				Exit For
			End If
		Next

		If targetDate = Nothing Then
			Throw New Exception("TargetDate was nothing.")
		End If

		'targetDate = targetDate.AddDays(7 * (weeknum - 1))
		Return targetDate
	End Function

	''' <summary>
	''' Returns the number of days since the specified week start day.
	''' </summary>
	''' <param name="targetDay"></param>
	''' <param name="weekStartDay"></param>
	''' <returns></returns>
	Public Function DaysSinceStartDay(targetDay As DayOfWeek, weekStartDay As DayOfWeek) As Integer
		Return (targetDay - weekStartDay + 7) Mod 7
	End Function

	''' <summary>
	''' Gets the date of the last occurrence of the specified DayOfWeek before the specified date.<br></br>
	''' Returns the first day of the work week specified by any date within the week starting on the specified weekStartDay.
	''' </summary>
	''' <param name="targetDate"></param>
	''' <param name="weekStartDay"></param>
	''' <returns></returns>
	Public Function LastOccurenceDay(targetDate As Date, weekStartDay As DayOfWeek) As Date
		' Adjust the target date to be the last occurrence of the target day of week
		Dim lastOccurrence As Date = targetDate.AddDays(-(targetDate.DayOfWeek - weekStartDay + 7) Mod 7)

		' Check if the last occurrence is after the target date, 
		' which would mean we've gone back too far, so we move back one more week
		If lastOccurrence > targetDate Then
			lastOccurrence = lastOccurrence.AddDays(-7)
		End If
		Return lastOccurrence
	End Function

	Public Function YearContainsWeek53(year As Integer) As Integer
		Return GetFirstDayOfWorkWeek(year, 53, Config.Properties.WeekStartDay).Year = year
	End Function



	Public Function GetChargeCodes() As List(Of ChargeCode)
		Dim cmd As New SQLiteCommand
		cmd.CommandText = "SELECT * FROM ChargeCodes ORDER BY ChargeCode DESC;"

		Dim dt As DataTable = Database.ExecuteReader(cmd)
		Dim dl As New List(Of ChargeCode)
		If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
			For i = 0 To dt.Rows.Count - 1
				If String.IsNullOrWhiteSpace(dt.Rows(i).Item("ChargeCode").ToString) Then Continue For
				dl.Add(New ChargeCode(dt.Rows(i).Item("ID"), dt.Rows(i).Item("ChargeCode").ToString, dt.Rows(i).Item("Description").ToString))
			Next
		End If

		Return dl
	End Function

	Public Function GetChargeCodesEnumerable() As String()
		Dim dl As List(Of ChargeCode) = GetChargeCodes()
		Dim dcl As New List(Of String)
		For Each c As ChargeCode In dl
			dcl.Add(c.Code)
		Next
		Return dcl.ToArray
	End Function


	Public Class ChargeCode
		Private Property _id As Integer
		Private Property _code As String
		Private Property _description As String

		Public Sub New(id As Integer, code As String, description As String)
			_id = id
			_code = code
			_description = description
		End Sub

		Public ReadOnly Property Id As Integer
			Get
				Return _id
			End Get
		End Property
		Public Property Code As String
			Get
				Return _code
			End Get
			Set(value As String)
				_code = value
			End Set
		End Property
		Public Property Description As String
			Get
				Return _description
			End Get
			Set(value As String)
				_description = value
			End Set
		End Property
	End Class
	''' <summary>
	''' an individual timesheet entry. Once an ID is set, updating any other property updates the database as well.
	''' </summary>
	Public Class TimesheetEntry
		Private Property _id As Integer
		Private Property _day As Date
		Private Property _startTime As Decimal
		Private Property _endTime As Decimal
		Private Property _comment As String
		Private Property _chargeCode As String

		Public Sub New(day As Date, startTime As Decimal, endTime As Decimal, comment As String, chargeCode As String, Optional id As Integer = Nothing)
			_id = id
			_day = day
			_startTime = startTime
			_endTime = endTime
			_comment = comment
			_chargeCode = chargeCode
		End Sub

		Public Sub New()

		End Sub

		Public Property Id As Integer
			Get
				Return _id
			End Get
			Set(value As Integer)
				_id = value
			End Set
		End Property

		Public Property Day As Date
			Get
				Return _day
			End Get
			Set(value As Date)
				_day = value
				If Not Id = Nothing Then
					Dim cmd As New SQLiteCommand
					cmd.CommandText = "UPDATE TimeEntries SET Date = @Date WHERE ID = @ID;"
					cmd.Parameters.AddWithValue("@Date", _day.ToString("yyyy-MM-dd"))
					cmd.Parameters.AddWithValue("@ID", _id)
					Database.ExecuteNonQuery(cmd)
				End If
			End Set
		End Property
		Public Property StartTime As Decimal
			Get
				Return _startTime
			End Get
			Set(value As Decimal)
				_startTime = value
				If Not Id = Nothing Then
					Dim cmd As New SQLiteCommand
					cmd.CommandText = "UPDATE TimeEntries SET StartTime = @StartTime WHERE ID = @ID;"
					cmd.Parameters.AddWithValue("@StartTime", _startTime)
					cmd.Parameters.AddWithValue("@ID", _id)
					Database.ExecuteNonQuery(cmd)
				End If
			End Set
		End Property
		Public Property EndTime As Decimal
			Get
				Return _endTime
			End Get
			Set(value As Decimal)
				_endTime = value
				If Not Id = Nothing Then
					Dim cmd As New SQLiteCommand
					cmd.CommandText = "UPDATE TimeEntries SET EndTime = @EndTime WHERE ID = @ID;"
					cmd.Parameters.AddWithValue("@EndTime", _endTime)
					cmd.Parameters.AddWithValue("@ID", _id)
					Database.ExecuteNonQuery(cmd)
				End If
			End Set
		End Property
		Public Property Comment As String
			Get
				Return _comment
			End Get
			Set(value As String)
				_comment = value
				If Not Id = Nothing Then
					Dim cmd As New SQLiteCommand
					cmd.CommandText = "UPDATE TimeEntries SET Comment = @Comment WHERE ID = @ID;"
					cmd.Parameters.AddWithValue("@Comment", _comment)
					cmd.Parameters.AddWithValue("@ID", _id)
					Database.ExecuteNonQuery(cmd)
				End If
			End Set
		End Property
		Public Property ChargeCode As String
			Get
				Return _chargeCode
			End Get
			Set(value As String)
				_chargeCode = value
				If Not Id = Nothing Then
					Dim cmd As New SQLiteCommand
					cmd.CommandText = "UPDATE TimeEntries SET ChargeCode = @ChargeCode WHERE ID = @ID;"
					cmd.Parameters.AddWithValue("@ChargeCode", _chargeCode)
					cmd.Parameters.AddWithValue("@ID", _id)
					Database.ExecuteNonQuery(cmd)
				End If
			End Set
		End Property

		Public ReadOnly Property DayIndex As Integer
			Get
				Dim weekStart As DayOfWeek = Config.Properties.WeekStartDay
				Return _day.AddDays(-_day.DayOfWeek + weekStart).DayOfYear \ 7
			End Get
		End Property

		Public Function AddToDatabase() As Integer
			Dim cmd As New SQLiteCommand
			cmd.CommandText =
"INSERT INTO TimeEntries (Date, StartTime, EndTime, Comment, ChargeCode)
VALUES (@Date, @StartTime, @EndTime, @Comment, @ChargeCode) RETURNING ID;"

			cmd.Parameters.AddWithValue("@Date", _day.ToString("yyyy-MM-dd"))
			cmd.Parameters.AddWithValue("@StartTime", _startTime)
			cmd.Parameters.AddWithValue("@EndTime", _endTime)
			cmd.Parameters.AddWithValue("@Comment", _comment)
			cmd.Parameters.AddWithValue("@ChargeCode", _chargeCode)

			Return Database.ExecuteScalar(cmd)
		End Function

		Public Sub Delete()
			If _id = Nothing Then Exit Sub
			Dim cmd As New SQLiteCommand
			cmd.CommandText = "DELETE FROM TimeEntries WHERE ID = @ID;"
			cmd.Parameters.AddWithValue("@ID", _id)
			Database.ExecuteNonQuery(cmd)
		End Sub
	End Class

	Public Class SummaryData
		Public Property Day As Date
		Public Property StartTime As Decimal
		Public Property EndTime As Decimal
		Public Property Hours As Decimal
		Public Property ChargeCodes As List(Of String)
		Public Property Comment As String

		Public Shared Function CreateSummaryData(Entries As List(Of TimesheetEntry)) As List(Of SummaryData)
			Dim summaryList As New List(Of SummaryData)

			For i = 0 To 6
				Dim day As Date = GetFirstDayOfWorkWeek(Entries(0).Day).AddDays(i)
				Dim dayEntries As List(Of TimesheetEntry) = Entries.Where(Function(x) x.Day = day).ToList

				If dayEntries.Count > 0 Then
					Dim summary As New SummaryData
					summary.Day = day
					summary.StartTime = dayEntries.Min(Function(x) x.StartTime)
					summary.EndTime = dayEntries.Max(Function(x) x.EndTime)
					summary.Hours = dayEntries.Sum(Function(x) x.EndTime - x.StartTime)
					summary.ChargeCodes = dayEntries.Select(Function(x) x.ChargeCode).Distinct.ToList
					summary.Comment = dayEntries(0).Comment

					summaryList.Add(summary)
				Else
					summaryList.Add(New SummaryData With {.Day = day})
				End If
			Next

			Return summaryList
		End Function
	End Class

	Public Class Database
		Public Shared ConnectionString As String = $"Data Source={Config.Properties.DatabasePath};Version=3;"

		Public Shared Sub Create()
			If Not IO.File.Exists(Config.Properties.DatabasePath) Then ' for now just create a blank database. will be backed up automatically in future... can check for backups and display to user if any are available
				Dim cmd As New SQLiteCommand
				cmd.CommandText = My.Resources.DbSchema

				ExecuteNonQuery(cmd)
			Else

			End If
		End Sub

		Public Shared Sub Update()
			UpdateChargeCodes()
		End Sub

		Public Shared Sub UpdateChargeCodes()
			Dim cmd As New SQLiteCommand
			cmd.CommandText =
"INSERT OR IGNORE INTO ChargeCodes (ChargeCode)
SELECT DISTINCT ChargeCode 
FROM TimeEntries
WHERE Date > date('now', '-14 day')
AND ChargeCode NOT IN (SELECT ChargeCode FROM ChargeCodes);"

			ExecuteNonQuery(cmd)
		End Sub

		Public Shared Function ExecuteReader(SqlCommand As SQLiteCommand) As DataTable
			Dim conn As New SQLiteConnection(ConnectionString, True)
			Dim ReturnTable As New DataTable
			SqlCommand.Connection = conn

			Try
				conn.Open()
				ReturnTable.Load(SqlCommand.ExecuteReader)
				conn.Close()
			Catch ex As Exception
				conn.Close()
				Throw New Exception($"SQLite reported a query error: {ex.Message}", ex)
			End Try

			conn.Dispose()

			Return ReturnTable
		End Function

		Public Shared Function ExecuteScalar(SqlCommand As SQLiteCommand) As Object
			Dim conn As New SQLiteConnection(ConnectionString, True)
			Dim ReturnObject As Object
			SqlCommand.Connection = conn

			Try
				conn.Open()
				ReturnObject = SqlCommand.ExecuteScalar
				conn.Close()
			Catch ex As Exception
				conn.Close()
				Throw New Exception($"SQLite reported a query error: {ex.Message}", ex)
			End Try

			conn.Dispose()

			Return ReturnObject
		End Function

		Public Shared Function ExecuteNonQuery(SqlCommand As SQLiteCommand) As Integer
			Dim conn As New SQLiteConnection(ConnectionString, True)
			Dim RowsAffected As Integer
			SqlCommand.Connection = conn

			Try
				conn.Open()
				RowsAffected = SqlCommand.ExecuteNonQuery
				conn.Close()
			Catch ex As Exception
				conn.Close()
				Throw New Exception($"SQLite reported a command error: {ex.Message}", ex)
			End Try

			conn.Dispose()

			Return RowsAffected
		End Function


	End Class
End Module
