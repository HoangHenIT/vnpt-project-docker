export default {
    getAllGroupRoles: (axios) => axios.get('/api/permission/roles/getAllRoler'),
    GetDanhSachNhomMenuChuaGan: (axios, data) => axios.get('/api/permission/RolePermission/getDanhSachMenuChuaGan?role_id=' + data),
    GetDanhSachNhomMenuDaGan: (axios, data) => axios.get('/api/permission/RolePermission/getDanhSachMenuDaGan?role_id=' + data),
    addRolePermission: (axios, data) => axios.post('/api/permission/RolePermission/addRolePermission', data),
   
    // InsertCategory: (axios, data) => axios.post('/api/permission/CategoryMenu/InsertCategory', data),
    // DeleteCategory: (axios, category_id) => axios.delete('/api/permission/CategoryMenu/DeleteCategory?category_id='+ category_id)
}