export default {
    getDanhSachMenuTheoNguoiDung: (axios, data) => axios.get('/api/permission/CategoryMenu/getDanhSachMenuTheoNguoiDung?employid=' + data),
}