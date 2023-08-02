namespace DemoStaffManager.Domain.Core.DbEntities;

public static class VersionablePropertyMethods {
    public static T GetActual<T>(this IEnumerable<T> list, DateTime dateTime) where T : IVersionableByDateOnly
    {
        if (list == null || !list.Any()) 
            throw new ArgumentNullException("Ошибка! Пустая или null последовательность.");
        
        var period = list.Single(item => item.Start <= DateOnly.FromDateTime(dateTime.Date) &&
                                         (item.End == null ||
                                          item.End >= DateOnly.FromDateTime(dateTime.Date)));
        
        return period;
    }
}