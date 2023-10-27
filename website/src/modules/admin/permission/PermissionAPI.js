export default {
    getAllGroupRoles: (axios) => axios.get('/api/permission/roles/getAllRoler'),
    GetDanhSachNhomMenuChuaGan: (axios, data) => axios.get('/api/permission/RolePermission/getDanhSachMenuChuaGan?role_id=' + data),
    GetDanhSachNhomMenuDaGan: (axios, data) => axios.get('/api/permission/RolePermission/getDanhSachMenuDaGan?role_id=' + data),
    addRolePermission: (axios, data) => axios.post('/api/permission/RolePermission/addRolePermission', data),
    removeRolePermission: (axios, data) => axios.post('/api/permission/RolePermission/removeRolePermission', data),

    GetDanhSachNguoiDungChuaGan: (axios, data) => axios.get('/api/permission/EmployerPermission/getDanhSachNguoiDungChuaGan?role_id=' + data),
    getDanhSachNguoiDungDaGan: (axios, data) => axios.get('/api/permission/EmployerPermission/getDanhSachNguoiDungDaGan?role_id=' + data),
    insertEmployPermission: (axios, data) => axios.post('/api/permission/EmployerPermission/insertEmployPermission', data),
    removeEmployPermission: (axios, data) => axios.post('/api/permission/EmployerPermission/deleteEmployPermission', data),
    getDanhSachNguoiDungChuaGan: (axios, data) => axios.get('/api/permission/EmployerPermission/getDanhSachNguoiDungChuaGan?role_id=' + data),
}