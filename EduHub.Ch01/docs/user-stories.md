User Stories - EduHub
Actor: Sinh viên
US-01: Đăng ký tham gia sự kiện
As a sinh viên,

I want đăng ký tham gia một sự kiện của CLB,

so that tôi có chỗ chính thức tại sự kiện đó.

Acceptance Criteria:

Given sự kiện còn chỗ, When tôi đăng ký, Then phiếu đăng ký được tạo với trạng thái Pending.

Given sự kiện đã đủ số lượng, When tôi đăng ký, Then hệ thống từ chối và báo hết chỗ.

US-02: Đăng ký tham gia CLB
As a sinh viên,

I want gửi đơn đăng ký gia nhập một câu lạc bộ,

so that tôi có thể trở thành thành viên chính thức và tham gia các hoạt động của CLB đó.

Acceptance Criteria:

Given tôi chưa phải là thành viên của CLB, When tôi điền đầy đủ thông tin và gửi đơn đăng ký, Then hệ thống lưu đơn với trạng thái Pending và gửi thông báo cho Ban CLB.

Given tôi đã gửi đơn đăng ký trước đó và đang chờ duyệt, When tôi nhấn gửi lại đơn, Then hệ thống từ chối và hiển thị thông báo "Bạn đã gửi đơn đăng ký cho CLB này rồi".

US-03: Check-in tại sự kiện
As a sinh viên,

I want quét mã QR để check-in khi tham dự sự kiện,

so that tôi xác nhận sự có mặt và được ghi nhận tham gia thành công.

Acceptance Criteria:

Given đơn đăng ký của tôi đã được chấp nhận và sự kiện đang trong thời gian điểm danh, When tôi đưa mã QR cá nhân cho Ban tổ chức quét, Then trạng thái tham gia chuyển thành Attended.

Given tôi chưa đăng ký sự kiện hoặc mã QR không hợp lệ, When thực hiện quét mã, Then hệ thống cảnh báo "Mã check-in không hợp lệ hoặc chưa đăng ký sự kiện".

Actor: Ban CLB
US-04: Tạo sự kiện
As a đại diện Ban CLB,

I want tạo một sự kiện mới với các thông tin chi tiết (tên, thời gian, địa điểm, số lượng giới hạn),

so that tôi có thể công bố và quản lý sinh viên đăng ký tham gia.

Acceptance Criteria:

Given tôi nhập đầy đủ các thông tin bắt buộc và thời gian tổ chức hợp lệ, When tôi bấm "Tạo sự kiện", Then sự kiện mới được lưu thành công và hiển thị công khai trên danh sách sự kiện.

Given tôi bỏ trống các trường bắt buộc (như Tên sự kiện hoặc Thời gian), When tôi bấm "Tạo sự kiện", Then hệ thống ngăn tạo và báo lỗi tại các trường thông tin bị thiếu.

US-05: Xem danh sách thành viên và xuất báo cáo
As a đại diện Ban CLB,

I want xem danh sách thành viên CLB và xuất dữ liệu ra file Excel/PDF,

so that tôi dễ dàng theo dõi, quản lý nhân sự và nộp báo cáo cho nhà trường.

Acceptance Criteria:

Given tôi truy cập mục Quản lý thành viên, When tôi bấm chọn "Xuất báo cáo", Then hệ thống tải về file chứa đầy đủ danh sách thành viên (Họ tên, MSSV, Chức vụ, Ngày gia nhập).

Given danh sách thành viên đang trống (0 thành viên), When tôi bấm chọn "Xuất báo cáo", Then hệ thống thông báo "Không có dữ liệu thành viên để xuất file".

Actor: Admin
US-06: Phê duyệt thành viên
As an Admin,

I want xét duyệt hoặc từ chối các đơn đăng ký tham gia CLB của sinh viên,

so that đảm bảo danh sách thành viên chính thức của các CLB luôn chính xác và hợp lệ.

Acceptance Criteria:

Given có đơn đăng ký ở trạng thái Pending, When tôi bấm nút "Phê duyệt", Then trạng thái chuyển thành Approved, tài khoản sinh viên được ghi nhận vào CLB và nhận được thông báo trúng tuyển.

Given đơn đăng ký không phù hợp, When tôi bấm nút "Từ chối" và nhập lý do, Then trạng thái chuyển thành Rejected và hệ thống gửi thông báo từ chối cùng lý do đến sinh viên.