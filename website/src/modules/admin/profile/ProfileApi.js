export default {
    getHistoryLoginInEmployer: (axios, data) => axios.post('/api/auth/getHistoryLoginInEmployer', data),
    getAllRoler: (axios) => axios.get('/api/auth/roles/getAllRoler'),
    insertEmployer: (axios, data) => axios.post('/api/employer/InsertEmployer', data)
}
  