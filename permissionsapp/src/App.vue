<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <a href="#" class="navbar-brand">Management Permissions</a>
      <div class="navbar-nav mr-auto">
        <li class="nav-item">
          <a href="/permission" class="nav-link">Permissions</a>
        </li>
        <li class="nav-item">
          <a href="/typeofpermission" class="nav-link">Type Of Permissions</a>
        </li>
      </div>
    </nav>

    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class App extends Vue {}
</script>

<style></style>
