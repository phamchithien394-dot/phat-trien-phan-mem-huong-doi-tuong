namespace EduHub.Ch01.Domain;

/// <summary>Trạng thái của phiếu đăng ký.</summary>
public enum RegistrationStatus
{
    /// <summary>Chờ xác nhận.</summary>
    Pending,
    /// <summary>Đã xác nhận.</summary>
    Confirmed,
    /// <summary>Đã huỷ.</summary>
    Cancelled
}

/// <summary>Phiếu đăng ký tham dự sự kiện của một thành viên.</summary>
public class Registration
{
    /// <summary>Mã định danh phiếu.</summary>
    public Guid Id { get; private set; }
    /// <summary>Khoá ngoại tới Member.</summary>
    public Guid MemberId { get; private set; }
    /// <summary>Khoá ngoại tới Event.</summary>
    public Guid EventId { get; private set; }
    /// <summary>Thời điểm đăng ký.</summary>
    public DateTime RegisteredAt { get; private set; }
    /// <summary>Trạng thái hiện tại.</summary>
    public RegistrationStatus Status { get; private set; }

    private Registration() { }

    /// <summary>Tạo phiếu đăng ký mới, trạng thái ban đầu là Pending.</summary>
    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException("MemberId không hợp lệ.", nameof(memberId));
        if (eventId == Guid.Empty)
            throw new ArgumentException("EventId không hợp lệ.", nameof(eventId));

        return new Registration
        {
            Id = Guid.NewGuid(),
            MemberId = memberId,
            EventId = eventId,
            RegisteredAt = DateTime.UtcNow,
            Status = RegistrationStatus.Pending
        };
    }

    /// <summary>Xác nhận phiếu; chỉ phiếu Pending mới được xác nhận.</summary>
    /// <exception cref="InvalidOperationException">Phiếu không ở trạng thái Pending.</exception>
    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException($"Không thể xác nhận phiếu đang ở trạng thái {Status}.");
        Status = RegistrationStatus.Confirmed;
    }

    /// <summary>Huỷ phiếu.</summary>
    /// <exception cref="InvalidOperationException">Phiếu đã bị huỷ trước đó.</exception>
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException("Phiếu đã được huỷ trước đó.");
        Status = RegistrationStatus.Cancelled;
    }
}