import AuthenApi from '../../components/login/LoginApi'

export const actions = {
  async login ({commit, state}, postData) {
    var response =null
    try {
      response = await AuthenApi.login(this._vm.axios, postData)
      if(response.data.success){
          // commit('setAccessInfo', response.data.data.token.access_token);
          // let user=response.data.data.user;
          // commit('setCurrentUser', {
          //   userid:user.userid,
          //   fullname:user.fullname
          // });
          //return response.data.data;
      }else{
        throw Error(response.data.message)
      }
      
    }catch (err) {
      throw err
    }
    return response
  },
  setCurrentUser ({ commit, state }, user) {
    commit('setCurrentUser', user)
  },
  setAccessInfo ({ commit, state }, accessInfo) {
    commit('setAccessInfo', accessInfo)
  },
  clearCurrentUser ({ commit, state }) {
    commit('clearCurrentUser')
  }
}