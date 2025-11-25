import LayoutMain from '@/layouts/MainLayout.vue'
import Profile from '../admin/profile/Profile.vue'
import CategoryMenu from '../admin/categorymenu/CategoryMenu.vue'
import PermissionIndex from '../admin/permission/Permission.vue'
import ProductList from './productlist/ProductList.vue'


export default [
    {
      path: '/admin',
      name: 'Admin',
      component: LayoutMain,
      redirect: '/admin/home',
      children: [
        {
          path: 'home',
          name: 'Home',
          component: () => import('../../components/home/Home.vue'),
          meta: {
            title: 'Trang chủ'
          }
        },
        {
          path: 'thong-tin-tai-khoang',
          name: 'Profile',
          component: Profile,
          meta: {
            title: 'Người dùng'
          }
        },
        {
          path: 'danh-sach-chuc-nang',
          name: 'CategoryMenu',
          component: CategoryMenu,
          meta: {
            title: 'Danh mục menu'
          }
        },
        {
          path: 'phan-quyen-nguoi-dung',
          name: 'PermissionIndex',
          component: PermissionIndex,
          meta: {
            title: 'Phân quyền'
          }
        },
        {
          path: 'quan-ly-san-pham',
          name: 'ProductList',
          component: ProductList,
          meta: {
            title: 'Danh sách sản phẩm'
          }
        },
        
      ]
    }
  ]