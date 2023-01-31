export default function auth ({ next, store }) {
    if (!this.$auth.isAuthenticated()) {
      return next({
        name: 'login'
      })
    }
    return next()
  }
  