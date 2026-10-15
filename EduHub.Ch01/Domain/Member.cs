namespace EduHub.Ch01.Domain;

/// <summary>Thành viên sinh viên của câu lạc bộ.</summary>
public class Member
{
    private const string EmailMarker = "@";

    /// <summary>Mã định danh thành viên.</summary>
    public Guid Id { get; private set; }
    /// <summary>Họ tên.</summary>
    public string Name { get; private set; } = string.Empty;
    /// <summary>Email liên hệ.</summary>
    public string Email { get; private set; } = string.Empty;
    /// <summary>Mã số sinh viên.</summary>
    public string StudentCode { get; private set; } = string.Empty;
    /// <summary>Thời điểm tham gia.</summary>
    public DateTime JoinedAt { get; private set; }

    private Member() { }

    /// <summary>Tạo thành viên mới sau khi kiểm tra dữ liệu.</summary>
    public static Member Create(string name, string email, string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên không được để trống.", nameof(name));
        if (string.IsNullOrWhiteSpace(email) || !email.Contains(EmailMarker))
            throw new ArgumentException("Email không hợp lệ.", nameof(email));
        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException("Mã sinh viên không được để trống.", nameof(studentCode));

        return new Member
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Email = email.Trim(),
            StudentCode = studentCode.Trim(),
            JoinedAt = DateTime.UtcNow
        };
    }

    /// <summary>Thành viên đang hoạt động nếu đã tham gia (JoinedAt không ở tương lai).</summary>
    public bool IsActive() => JoinedAt <= DateTime.UtcNow;
}