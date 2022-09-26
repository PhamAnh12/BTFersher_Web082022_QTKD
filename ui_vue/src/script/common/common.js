import enumeration from "./enumeration";
export default {

    newEmployeeCode() {
        try {

            fetch("http://localhost:5108/api/v1/Employees/new-code")
                .then((res) => res.json())
                .then((res) => {

                    return res;
                })
                .catch((error) => {
                    console.log("Error! Could not reach the API. " + error);
                });

        } catch (error) {
            console.log(error);
        }


    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(12/09/2022)
     */
    formatDate(dateSrc) {

        try {
            if (dateSrc) {
                let dateString = dateSrc.slice(0, 10);
                let date = new Date(dateString);
                let year = date.getFullYear().toString(),
                    month = (date.getMonth() + 1).toString().padStart(2, "0"),
                    day = date.getDate().toString().padStart(2, "0");
                return `${day}/${month}/${year}`;
            }
            return "";

        } catch (error) {
            console.log(error)
        }

    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee form nhập
     * PCTUANANH(12/09/2022)
     */
    formatDate2(dateSrc) {
        try {
            if (dateSrc) {
                let date = new Date(dateSrc);
                date = date.toJSON().slice(0, 10);
                return date;
            }


        } catch (error) {
            console.log(error);

        }

    },
    /*
     * Hàm dùng để  chuyển đổi giới tính từ các số "0,1,2"sang "Nam, Nữ, Khác" 
     * PCTUANANH(16/09/2022)
     */
    formatGender(gender) {
        try {
            let GenderName;
            switch (gender) {
                case 0:
                    GenderName = enumeration.GenderName.Male;
                    break;
                case 1:
                    GenderName = enumeration.GenderName.Female
                    break;
                case 2:
                    GenderName = enumeration.GenderName.Other;
                    break;
                default:
                    GenderName = '';
            }
            return GenderName;
        } catch (error) {
            console.log(error);
        }



    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(12/09/2022)
     */
    maxDate() {

        try {

            let date = new Date(),
                year = date.getFullYear().toString(),
                month = (date.getMonth() + 1).toString().padStart(2, '0'),
                day = date.getDate().toString().padStart(2, '0');
            return `${year}-${month}-${day}`;


        } catch (error) {
            console.log(error)
        }

    },


    /*
     * Hàm xử lý dữ liệu tiếng việte
     * PCTUANANH(26/09/2022)
     */
    processData(Text) {
        try {
            Text = Text.trim().toLowerCase();
            //Xoa khoảng trắng
            Text = Text.replace(/\s\s+/g, ' ');
            //Xóa dấu tiếng việt trong chuỗi
            Text = Text.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
            Text = Text.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
            Text = Text.replace(/ì|í|ị|ỉ|ĩ/g, "i");
            Text = Text.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
            Text = Text.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
            Text = Text.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
            Text = Text.replace(/đ/g, "d");
            Text = Text.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, "");

            return Text;
        } catch (error) {
            console.log(error)
        }

    }
}