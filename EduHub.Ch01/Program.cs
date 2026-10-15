using System.Text;
using EduHub.Ch01.Domain;

const string Separator = "====================";
const string ClubName = "Tech Club";
const string EventTitle = "Workshop AI";
const int EventCapacity = 50;
const int DaysUntilEvent = 7;

Console.OutputEncoding = Encoding.UTF8;

static void PrintStep(string title) => Console.WriteLine($"\n{Separator} {title} {Separator}");

// Bước 1
PrintStep("Bước 1: Tạo CLB");
var club = Club.Create(ClubName, "Câu lạc bộ công nghệ của sinh viên ĐHĐT");
Console.WriteLine($"Đã tạo CLB: {club.Name} - {club.Description}");

// Bước 2
PrintStep("Bước 2: Thêm 3 thành viên");
var m1 = Member.Create("Nguyễn Văn An", "an@example.com", "SV001");
var m2 = Member.Create("Trần Thị Bình", "binh@example.com", "SV002");
var m3 = Member.Create("Lê Văn Cường", "cuong@example.com", "SV003");
foreach (var m in new[] { m1, m2, m3 })
{
    club.AddMember(m);
    Console.WriteLine($"Đã thêm: {m.Name} ({m.StudentCode})");
}
Console.WriteLine($"Số thành viên của {club.Name}: {club.MemberCount()}");

// Bước 3
PrintStep("Bước 3: Tạo sự kiện");
var ev = Event.Create(club.Id, EventTitle, DateTime.Now.AddDays(DaysUntilEvent), EventCapacity, false);
Console.WriteLine($"Sự kiện: {ev.Title} | Sức chứa: {ev.Capacity} | Ngày: {ev.Date:dd/MM/yyyy}");

// Bước 4
PrintStep("Bước 4: Đăng ký và xác nhận");
var registrations = new List<Registration>();
foreach (var m in new[] { m1, m2 })
{
    if (!ev.HasCapacity(registrations.Count))
    {
        Console.WriteLine("Sự kiện đã hết chỗ.");
        break;
    }
    var reg = Registration.Create(m.Id, ev.Id);
    registrations.Add(reg);
    Console.WriteLine($"{m.Name} đăng ký -> Status = {reg.Status}");
    reg.Confirm();
    Console.WriteLine($"{m.Name} sau khi Confirm() -> Status = {reg.Status}");
}

// Bước 5
PrintStep("Bước 5: Check-in");
var checkIns = new List<CheckIn>();
var firstReg = registrations[0];
if (firstReg.Status == RegistrationStatus.Confirmed)
{
    var checkIn = CheckIn.Create(firstReg.Id, CheckInMethod.Manual);
    checkIns.Add(checkIn);
    Console.WriteLine(checkIn.Summary());
}

// Bước 6
PrintStep("Bước 6: Báo cáo tham dự");
var members = new[] { m1, m2, m3 };
Console.WriteLine($"Số đăng ký: {registrations.Count}");
Console.WriteLine($"Số check-in: {checkIns.Count}");
Console.WriteLine("Danh sách đã check-in:");
foreach (var c in checkIns)
{
    var reg = registrations.First(r => r.Id == c.RegistrationId);
    var name = members.First(m => m.Id == reg.MemberId).Name;
    Console.WriteLine($" - {name}");
}

// Bước 7 (thêm): vi phạm luật nghiệp vụ
PrintStep("Bước 7: Thử Confirm() phiếu đã huỷ");
var cancelled = Registration.Create(m3.Id, ev.Id);
cancelled.Cancel();
try
{
    cancelled.Confirm();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Bắt được lỗi nghiệp vụ: {ex.Message}");
}