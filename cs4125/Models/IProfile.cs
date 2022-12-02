namespace cs4125.Models
{
    public interface IProfile
    {
        void updateEvent(Event ev);
        void updateEventCancelled(Event ev);
    }
}