namespace DemoStaffManager.Domain.Core.DbEntities;

public static class VersionablePropertyMethods {
    public static T GetActual<T>(this IEnumerable<T> list, DateOnly date) where T : IVersionableByDateOnly
    {
        T period = default;
        if (list == null || !list.Any())
            return period;
        
        period = list.SingleOrDefault(item => item.Start <= date &&
                                         (item.End == null ||
                                          item.End >= date));
        return period;
    }
}