namespace avb_meeting_appointment_exam
{
    public class MeetingManager
    {
        List<Meeting> _allMeetings;
        public MeetingManager(List<Meeting> meetings)
        {
            _allMeetings = meetings;
        }

        /// <summary>
        /// Add new meeting to the calendar
        /// </summary>
        /// <param name="meeting"></param>
        public void AddMeeting(Meeting meeting)
        {
            if(IsValidMeeting(meeting))
            {
               _allMeetings.Add(meeting);
            }
            else
            {
                throw new Exception("Meeting object is invalid!");
            }     
        }

        /// <summary>
        /// Remove an existing meeting on the calendar
        /// </summary>
        /// <param name="meeting"></param>
        public void DeleteMeeting(Meeting meeting)
        {
            _allMeetings.Remove(meeting);
        }

        /// <summary>
        /// Use to validate the correctness of meeting object. Check if EndDate is later than StartDate
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>bool</returns>
        private bool IsValidMeeting(Meeting meeting)
        {
            int result = DateTime.Compare(meeting.StartDate, meeting.EndDate);
            if(result < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Display meetings in console
        /// </summary>
        /// <param name="meetings"></param>
        public void DisplayMeetings(List<Meeting> meetings)
        {
            foreach (Meeting meeting in meetings)
            {
                Console.WriteLine("StartDate: {0} - EndDate: {1}", meeting.StartDate.ToString("MM/dd/yyyy HH:mm") , meeting.EndDate.ToString("MM/dd/yyyy HH:mm"));
            }
        }

        /// <summary>
        /// Get all meetings with conflicting schedule.
        /// </summary>
        /// <returns>List<Meeting></returns>
        public List<Meeting> GetMeetingsWithOverlaps()
        {
            List<Meeting> sortedMeetingList = _allMeetings.OrderBy(x => x.StartDate).ToList();
            List<Meeting> overLappingMeetings = new List<Meeting>();

            for (int i = 0; i < sortedMeetingList.Count; i++)
            {
                Meeting currentMeetingSchedule = sortedMeetingList[i];
                List<Meeting> greaterDates = sortedMeetingList.Where(x => x.StartDate > currentMeetingSchedule.StartDate && x != currentMeetingSchedule).ToList();
                foreach(Meeting meeting in greaterDates)
                {
                    bool overlap = IsOverlappingMeetings(currentMeetingSchedule, meeting);
                    if (overlap)
                    {
                        overLappingMeetings.Add(currentMeetingSchedule);
                        overLappingMeetings.Add(meeting);
                    }
                }
            }

            return overLappingMeetings;
        }

        /// <summary>
        /// Check if 2 date ranges are overlapping
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns>bool</returns>
        private bool IsOverlappingMeetings(Meeting current, Meeting next)
        {
            bool isStartDateOverlap = next.StartDate > current.StartDate && next.StartDate < current.EndDate;
            bool isEndDateOverlap = next.EndDate > current.StartDate && next.EndDate < current.EndDate;

            return isStartDateOverlap || isEndDateOverlap;
        }

        /// <summary>
        /// Use to populate meetingsList using dummy data
        /// </summary>
        public void CreateMockupMeetings()
        {
            _allMeetings.Add(
                new Meeting
                (    
                    new DateTime(2016, 01, 01, 9, 0, 0),
                    new DateTime(2016, 01, 01, 11, 0, 0)
                ));
            _allMeetings.Add(
                new Meeting
                (
                    new DateTime(2016, 1, 11, 10, 0, 0),
                    new DateTime(2016, 1, 11, 13, 30, 0)
                ));
            _allMeetings.Add(
                new Meeting
                ( 
                    new DateTime(2016, 01, 11, 13, 30, 0),
                    new DateTime(2016, 01, 11, 16, 0, 0)
                ));
            _allMeetings.Add(
                new Meeting
                (
                    new DateTime(2016, 01, 05, 9, 0, 0),
                    new DateTime(2016, 01, 05, 11, 0, 0)
                ));
            _allMeetings.Add(
                new Meeting
                (
                    new DateTime(2015, 12, 29, 9, 0, 0),
                    new DateTime(2016, 01, 01, 10, 0, 0)
                ));
            _allMeetings.Add(
                new Meeting
                (
                    new DateTime(2016, 01, 01, 12, 0, 0),
                    new DateTime(2016, 01, 01, 14, 0, 0)
                ));
            _allMeetings.Add(
                new Meeting
                (
                    new DateTime(2016, 01, 05, 10, 0, 0),
                    new DateTime(2016, 01, 05, 12, 0, 0)
                ));
            _allMeetings.Add(
                new Meeting
                (
                    new DateTime(2016, 01, 01, 11, 0, 0),
                    new DateTime(2016, 01, 01, 14, 0, 0)
                ));
        }
    }
}
