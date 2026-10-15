namespace EduHub.Ch01.Domain;

/// <summary>Hình thức điểm danh.</summary>
public enum CheckInMethod
{
    /// <summary>Điểm danh thủ công.</summary>
    Manual,
    /// <summary>Quét mã QR.</summary>
    QrCode,
    /// <summary>Điểm danh trực tuyến.</summary>
    Online
}

/// <summary>Bản ghi điểm danh tại sự kiện.</summary>
public class CheckIn
{
    /// <summary>Mã định danh bản ghi.</summary>
    public Guid Id { get; private set; }
    /// <summary>Khoá ngoại tới Registration.</summary>
    public Guid RegistrationId { get; private set; }
    /// <summary>Thời điểm điểm danh.</summary>
    public DateTime CheckedInAt { get; private set; }
    /// <summary>Hình thức điểm danh.</summary>
    public CheckInMethod Method { get; private set; }

    private CheckIn() { }

    /// <summary>Tạo bản ghi điểm danh mới.</summary>
    public static CheckIn Create(Guid registrationId, CheckInMethod method)
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException("RegistrationId không hợp lệ.", nameof(registrationId));
        if (!Enum.IsDefined(method))
            throw new ArgumentException("Hình thức điểm danh không hợp lệ.", nameof(method));

        return new CheckIn
        {
            Id = Guid.NewGuid(),
            RegistrationId = registrationId,
            CheckedInAt = DateTime.UtcNow,
            Method = method
        };
    }

    /// <summary>Trả về chuỗi mô tả bản ghi điểm danh.</summary>
    public string Summary() => $"CheckIn {Id} lúc {CheckedInAt:HH:mm:ss} bằng {Method}";
}