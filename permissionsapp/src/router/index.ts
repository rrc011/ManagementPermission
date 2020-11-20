import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Home from "../views/Home.vue";
import Permissions from "../views/Permissions.vue";
import PermissionsCreate from "../views/PermissionsCreate.vue";
import TypeOfPermission from "../views/TypeOfPermission.vue";
import TypeOfPermissionCreate from "../views/TypeOfPermissionCreate.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/permission",
    name: "Permissions",
    component: Permissions,
  },
  {
    path: "/permission/create/:id",
    component: PermissionsCreate,
  },
  {
    path: "/typeofpermission",
    component: TypeOfPermission,
  },
  {
    path: "/typeofpermission/create/:id",
    component: TypeOfPermissionCreate,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
