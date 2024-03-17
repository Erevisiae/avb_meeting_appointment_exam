// See https://aka.ms/new-console-template for more information
using avb_meeting_appointment_exam;
List<Meeting> meetings = new List<Meeting>();
//Current meetings is emtpy and prepopulated by CreateMockupMeetings()
MeetingManager meetingManager = new MeetingManager(meetings);

meetingManager.CreateMockupMeetings();
List<Meeting> meetingsWithOverlaps = meetingManager.GetMeetingsWithOverlaps();
meetingManager.DisplayMeetings(meetingsWithOverlaps);

