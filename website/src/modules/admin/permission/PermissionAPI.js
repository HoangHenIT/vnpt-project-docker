export default {
    getAllGroupRoles: (axios) => axios.get('/api/permission/roles/getAllRoler'),
    // getCategoryFath: (axios) => axios.get('/api/permission/CategoryMenu/getCategoryFath'),
    // InsertCategory: (axios, data) => axios.post('/api/permission/CategoryMenu/InsertCategory', data),
    // DeleteCategory: (axios, category_id) => axios.delete('/api/permission/CategoryMenu/DeleteCategory?category_id='+ category_id)
}