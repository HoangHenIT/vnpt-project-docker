export default {
    getHistoryLoginInEmployer: (axios, data) => axios.post('/api/auth/getHistoryLoginInEmployer', data),
    insertEmployer: (axios, data) => axios.post('/api/employer/InsertEmployer', data)
}
  