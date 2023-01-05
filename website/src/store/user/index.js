// khai báo 1 store
import { actions } from './actions'
import { getters } from './getters'
import { mutations } from './mutations'

const state = {
  user: {},
  accessToken: ''
}

const namespaced = true

export const user = {
  namespaced,
  state,
  getters,
  actions,
  mutations
}
