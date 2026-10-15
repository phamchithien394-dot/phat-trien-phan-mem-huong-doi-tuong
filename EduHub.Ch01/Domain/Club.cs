namespace EduHub.Ch01.Domain;

/// <summary>Câu lạc bộ sinh viên.</summary>
public class Club
{
    private readonly List<Member> _members = new();

    /// <summary>Mã định danh CLB.</summary>
    public Guid Id { get; private set; }
    /// <summary>Tên CLB.</summary>
    public string Name { get; private set; } = string.Empty;
    /// <summary>Mô tả CLB.</summary>
    public string Description { get; private set; } = string.Empty;
    /// <summary>Thời điểm tạo CLB.</summary>
    public DateTime CreatedAt { get; private set; }
    /// <summary>Danh sách thành viên (chỉ đọc từ bên ngoài).</summary>
    public IReadOnlyList<Member> Members => _members;

    private Club() { }

    /// <summary>Tạo CLB mới sau khi kiểm tra dữ liệu.</summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên CLB không được để trống.", nameof(name));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Mô tả không được để trống.", nameof(description));

        return new Club
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Description = description.Trim(),
            CreatedAt = DateTime.UtcNow
        };
    }

    /// <summary>Thêm thành viên vào CLB; không cho thêm null hoặc trùng.</summary>
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);
        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException("Thành viên đã có trong CLB.");
        _members.Add(member);
    }

    /// <summary>Số thành viên hiện có.</summary>
    public int MemberCount() => _members.Count;
}