import Vue from "vue";
import Router from "vue-router";

// layout
// import homelayout from '@/layouts/homelayout'

// page
import dashboard from "@/components/dashboard";
import login from "@/components/home/login";

// example
import ProductList from "@/components/ProductList";
import ShoppingCart from "@/components/ShoppingCart";
//

// import store from '@/store'

Vue.use(Router);
const router = new Router({
  // mode: 'history',
  routes: [
    {
      path: "/",
      name: "dashboard",
      component: dashboard,
      meta: { requiresLogin: true }
    },
    {
      path: "/ProductList",
      name: "ProductList",
      component: ProductList
    },
    {
      path: "/ShoppingCart",
      name: "ShoppingCart",
      component: ShoppingCart
    },
    {
      path: "/dang-nhap",
      name: "login",
      component: login,
      meta: {
        layout: "homelayout" // name of the layout
      }
    }
  ]
});
export default router;
