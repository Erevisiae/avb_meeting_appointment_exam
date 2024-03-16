namespace avb_meeting_appointment_exam
{
    public class Meeting
    {
        public Meeting(DateTime start, DateTime end)
        {
            StartDate = start;
            EndDate = end;
        }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
