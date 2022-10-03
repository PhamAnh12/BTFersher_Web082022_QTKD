export default {
    setLocalStorage() {

        const urlBase = process.env.VUE_APP_URL;
        const urlDepartment = `${urlBase}/Departments`
        // Thực hiện lấy dữ liệu từ api:
        fetch(urlDepartment)
            .then((res) => res.json())
            .then((res) => {
                localStorage.setItem('departments', JSON.stringify(res));
            })
            .catch((res) => {
                console.log(res);
            });
    }
}