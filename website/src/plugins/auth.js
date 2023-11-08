import token from "./token";
var AuthPlugin = {
  data: {
    CLIENT_KEY: "WebClient-Token",
  },
  authenticate: function (stringToken) {
    this.setToken(stringToken);
  },
  
  isAuthenticated: function(){
    return token.getTokenFromStorage() != null;
  },
  destroy: function () {
    token.destroy();
    localStorage.clear();
  },
  ExpiresToken: function(){
    let newday =  new Date().toString("dd/mm/yyyy HH24:MI:SS");
    let expires = token.getTokenExpired();
    if(expires == null){
      return false
    }else{
      let e_expires = expires.toString("dd/mm/yyyy HH24:MI:SS")
      if(e_expires <= newday){
        return false
        
      }
      token.destroy();
      localStorage.clear();
      return true
    }
  },
  setToken: function (stringToken) {
    token.setToken(stringToken);
  },
  getToken: function () {
    return token.getToken();
  },
  getClaims: function () {
    return token.getClaims();
  },
  getEmployerToken: function(){
    return token.getEmployerToken();
  },
  getEmployerId: function(){
    return token.getEmployerId();
  },
  
  saveClientInfoToStorage: function (clientInfo) {
    try {
      localStorage.removeItem(this.data.CLIENT_KEY);
      localStorage.setItem(this.data.CLIENT_KEY, JSON.stringify(clientInfo));
      return true;
    } catch (error) {
      return false;
    }
  },
  getClientInfoFromStorage: function () {
    if (localStorage.hasOwnProperty(this.data.CLIENT_KEY))
      return JSON.parse(localStorage.getItem(this.data.CLIENT_KEY));
    else return null;
  },
  getClientInfoProperty: function (name) {
    var obj = this.getClientInfoFromStorage();
    if (obj !== null) {
      return obj[name];
    } else {
      return null;
    }
  },
};

export default function (Vue) {
  Vue.auth = AuthPlugin;
  Object.defineProperties(Vue.prototype, {
    $auth: {
      get: function () {
        return Vue.auth;
      }
    }
  });
}
