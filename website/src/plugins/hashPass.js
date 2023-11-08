import { readonly } from 'vue';

const CryptoJS = require('crypto-js');
const  passphrase = "Ho@ngHeN@97231#%";
export default {
  decrypt(sender) {
      const data = CryptoJS.enc.Base64.parse(sender);
      const keys = CryptoJS.MD5(passphrase).toString(CryptoJS.enc.Utf8);

      const decryptedData = CryptoJS.TripleDES.decrypt({
          ciphertext: data
      }, keys, {
          mode: CryptoJS.mode.ECB,
          padding: CryptoJS.pad.Pkcs7
      });

      return decryptedData.toString(CryptoJS.enc.Utf8);
    },
    encrypt(sender) {
      const data = CryptoJS.enc.Utf8.parse(sender);
      // const keys = CryptoJS.MD5(passphrase);//CryptoJS.MD5(passphrase).toString(CryptoJS.enc.Utf8);
      // const ks = CryptoJS.enc.Utf8.parse(keys);
      const keys = CryptoJS.MD5(passphrase).toString(CryptoJS.enc.Utf8);
      const encryptedData = CryptoJS.TripleDES.encrypt(data, keys, {
          mode: CryptoJS.mode.ECB,
          padding: CryptoJS.pad.Pkcs7
      });
  
      return encryptedData.toString();
  }
}