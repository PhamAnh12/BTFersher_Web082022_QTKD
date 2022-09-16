export default {

    newEmployeeCode() {
        //    let newEmpCode =employeeCode.substring(3);
        //    newEmpCode = parseInt(newEmpCode)+1
        return `NV-00123`

    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(12/09/2022)
     */
    formatDate(dateSrc) {
        let date = new Date(dateSrc),
            year = date.getFullYear().toString(),
            month = (date.getMonth() + 1).toString().padStart(2, '0'),
            day = date.getDate().toString().padStart(2, '0');

        return `${day}/${month}/${year}`;
    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee form nhập
     * PCTUANANH(12/09/2022)
     */
    formatDate2(dateSrc) {
        let date = new Date(dateSrc);
        // let day = date.getDate() ;
        // date.setDate(day);
        date = date.toISOString().substring(0, 10);
        return date;

    }
}