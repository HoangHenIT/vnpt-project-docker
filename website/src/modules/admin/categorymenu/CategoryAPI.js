export default {
    getAllCategory: (axios) => axios.get('/api/permission/CategoryMenu/getAllCategory'),
    getCategoryFath: (axios) => axios.get('/api/permission/CategoryMenu/getCategoryFath'),
    InsertCategory: (axios, data) => axios.post('/api/permission/CategoryMenu/InsertCategory', data),
    // deleteEmployer: (axios, data) => axios.delete('/api/employer/deleteEmployer', data)
}
  