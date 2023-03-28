export default {
    getAllGroupRoles: (axios) => axios.get('/api/permission/roles/getAllRoler'),
    InsertRoles: (axios, data) => axios.post('/api/permission/roles/insertRoler', data),
    updateRoler: (axios, data) => axios.post('/api/permission/roles/updateRoler', data),
    // InsertCategory: (axios, data) => axios.post('/api/permission/CategoryMenu/InsertCategory', data),
    // DeleteCategory: (axios, category_id) => axios.delete('/api/permission/CategoryMenu/DeleteCategory?category_id='+ category_id)
}