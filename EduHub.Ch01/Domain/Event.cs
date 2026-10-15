namespace EduHub.Ch01.Domain;

/// <summary>Sự kiện do CLB tổ chức.</summary>
public class Event
{
    /// <summary>Mã định danh sự kiện.</summary>
    public Guid Id { get; private set; }
    /// <summary>Khoá ngoại tới CLB tổ chức.</summary>
    public Guid ClubId { get; private set; }
    /// <summary>Tiêu đề sự kiện.</summary>
    public string Title { get; private set; } = string.Empty;
    /// <summary>Ngày diễn ra.</summary>
    public DateTime Date { get; private set; }
    /// <summary>Sức chứa tối đa.</summary>
    public int Capacity { get; private set; }
    /// <summary>Sự kiện trực tuyến hay không.</summary>
    public bool IsOnline { get; private set; }

    private Event() { }

    /// <summary>Tạo sự kiện mới sau khi kiểm tra dữ liệu.</summary>
    public static Event Create(Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentException("ClubId không hợp lệ.", nameof(clubId));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tiêu đề không được để trống.", nameof(title));
        if (capacity <= 0)
            throw new ArgumentException("Sức chứa phải lớn hơn 0.", nameof(capacity));

        return new Event
        {
            Id = Guid.NewGuid(),
            ClubId = clubId,
            Title = title.Trim(),
            Date = date,
            Capacity = capacity,
            IsOnline = isOnline
        };
    }

    /// <summary>Còn chỗ nếu số đã đăng ký nhỏ hơn sức chứa.</summary>
    public bool HasCapacity(int registeredCount) => registeredCount < Capacity;
}