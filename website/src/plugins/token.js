import { emit } from "node-notifier";

// import jwtdecode from "jwt-decode";
export default {
  data: {
    TOKEN_KEY: "WebClient-Token",
  },
  setToken: function (token) {
    try {
      localStorage.setItem(this.data.TOKEN_KEY, JSON.stringify(token));
      return true;
    } catch (error) {
      return false;
    }
  },
  getTokenFromStorage(){
    return JSON.parse(localStorage.getItem(this.data.TOKEN_KEY));
  },
  getAuthorization: function (){
    let tt = this.getTokenType();
    let tv = this.getToken();
    if(!(tt == null || tv == null)){
      return tt.charAt(0).toUpperCase() + tt.slice(1) + " " + tv;
    }
    return null;
  },
  getToken: function () {
    try {
      let t = this.getTokenFromStorage();
      return t.access_token;
    } catch (error) {
      return null;
    }
  },
  getTokenType: function () {
    try {
      let t = this.getTokenFromStorage();
      return t.token_type;
    } catch (error) {
      return null;
    }
  },
  getTokenExpired: function () {
    try {
      let t = this.getTokenFromStorage();
      return t.expires_in;
    } catch (error) {
      return null;
    }
  },
  getClaims: function () {
    try {
      var token = this.getToken();
      if (token !== null && token !== "") {
        return jwtdecode(token);
      } else {
        return null;
      }
    } catch (e) {
      return null;
    }
  },
  destroy: function(){
    try {
      localStorage.removeItem(this.data.TOKEN_KEY);
      return true;
    } catch (error) {
       this.$root.context.logOut();
    }
  },
  getEmployerToken: function(){
    try {
      let t = this.getTokenFromStorage(); 
      return t.data.employer
    } catch (error)
    {
      this.destroy();
    }
  },
  getEmployerId: function(){
    try {
      let t = this.getTokenFromStorage(); 
      return t.data.employer.employer_id
    } catch (error)
    {
      this.destroy();
    }
  }
}
