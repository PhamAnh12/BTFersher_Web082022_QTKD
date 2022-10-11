export default {
    FormMode: {
        Add: 1,
        Edit: 2,
        Delete: 3,
    },
    SaveMode: {
        Save: 1,
        SaveAdd: 2
    },
    GenderName: {
        Male: "Nam",
        Female: "Nữ",
        Other: "Khác"
    },
    KeyCode: {
        Enter: 13,

    },
    Errors: {
        errorName: "Tên không được để trống",
        errorCode: "Mã không được để trống",
        errorDepartment: "Đơn vị không được để trống",
        errorEmail:"Email không đúng định dạng",
        errorDate: "Ngày nhập không được lớn hơn ngày hiện tại"
    },
    keyCode: { //sk bàn phím
        LEFT: 37,
        UP: 38,
        RIGHT: 39,
        DOWN: 40,
        ENTER: 13,
        ESC: 27,
        S: 83
    },
    listRecordPages: [
        {

            num: 10,
            textData: '10 bản ghi trên một trang'
        },
        {
            num: 20,
            textData: '20 bản ghi trên một trang'
        },
        {
            num: 30,
            textData: '30 bản ghi trên một trang'
        },
        {
            num: 50,
            textData: '50 bản ghi trên một trang'
        },
        {
            num: 100,
            textData: '100 bản ghi trên một trang'
        }
    ],
    textErrorBackend:{
        textCodeLeft: "Mã nhân viên ",
        textCodeRight:"đã tồn tại vui lòng kiểm tra lại",
        textServer:"Đã có lỗi Xảy ra vui lòng liên hệ MISA"
    },
    resErrorCodes:{
        errorDuplicate : 3,
    },
    nameFileExport: "Danh sách nhân viên",
    textDelete: " Bạn muốn thực sự muốn xóa Nhân viên có mã là",
    textToast:{
        addSuccess:"Thêm thành công",
        updateSuccess:"Sửa thành công",
        deleteSuccess:"Xóa thành công"
    }
    



}