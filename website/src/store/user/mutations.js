// các hàm xử lý các thuộc tính của đối tượng trong store
export const mutations = {
    setCurrentUser (state, user) {
      state.user = user
    },
    setAccessInfo (state, accessInfo) {
      state.accessToken = accessInfo;
      var temp = {
        accessToken:accessInfo,
        user:state.user
      };

      document.cookie = "web_token=" +  JSON.stringify(temp);
    },
    clearCurrentUser (state) {
      state.user = undefined
      state.accessToken = undefined
    }
}