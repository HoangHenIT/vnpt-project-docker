export default {
    getHistoryLoginInEmployer: (axios, data) => axios.post('/api/auth/getHistoryLoginInEmployer', data),
    getAllRoler: (axios) => axios.get('/api/permission/roles/getAllRoler'),
    getAllEmployer: (axios) => axios.get('/api/employer/getAllEmployer'),
    insertEmployers: (axios, data) => axios.post('/api/employer/InsertEmployer', data),
    deleteEmployer: (axios, data) => axios.delete('/api/employer/deleteEmployer', data)
}
  