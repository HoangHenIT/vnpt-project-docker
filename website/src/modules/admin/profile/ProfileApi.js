export default {
    getHistoryLoginInEmployer: (axios, data) => axios.post('/api/auth/getHistoryLoginInEmployer', data)
    // getHistoryLoginInEmployer: (axios) => axios.get('/api/auth/getHistoryLoginInEmployer')
}
  