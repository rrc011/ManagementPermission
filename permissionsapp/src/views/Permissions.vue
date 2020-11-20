<template>
  <div>
    <div class="card">
      <div class="card-body">
        <h5 class="card-title">
          List of Permissions
          <button
            @click="$router.push('/permission/create/0')"
            type="button"
            class="btn btn-primary float-right mb-2"
          >
            Create
          </button>
        </h5>

        <table class="table table-bordered">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Name</th>
              <th scope="col">Last Name</th>
              <th scope="col">Type of Permission</th>
              <th>Options</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in list" :key="item.id">
              <th scope="row">{{ index + 1 }}</th>
              <td>{{ item.name }}</td>
              <td>{{ item.lastName }}</td>
              <td>{{ item.typeOfPermission.description }}</td>
              <td>
                <div class="btn-group" role="group" aria-label="Basic example">
                  <button
                    type="button"
                    class="btn btn-primary"
                    @click="goToEditPage(item.id)"
                  >
                    Edit
                  </button>
                  <button
                    type="button"
                    @click="remove(item.id)"
                    class="btn btn-danger"
                  >
                    Delete
                  </button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import PermissionsService from "../services/permissions.service";
import { PermissionDto } from "../models/PermissionDto";
import permissionsService from "../services/permissions.service";

@Component
export default class Permissions extends Vue {
  list: PermissionDto[] = [];

  init() {
    permissionsService.getAll().then((r: any) => {
      this.list = r["data"]["data"];
    });
  }

  goToEditPage(id: number) {
    this.$router.push(`/permission/create/${id}`);
  }

  created() {
    this.init();
  }

  remove(id: number) {
    this.question(() => {
      PermissionsService.delete(id).then(() =>
        this.success("Success").then(() => {
          this.init();
        })
      );
    }, "");
  }

  question(callback: () => any, message: string, title?: string) {
    return this.$swal
      .fire({
        title: title ? title : "Are you sure?",
        text: message,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "yes!",
      })
      .then((result) => {
        if (result.isConfirmed) {
          callback();
        }
      });
  }

  success(message: string) {
    return this.$swal.fire({
      icon: "success",
      title: message,
      showConfirmButton: true,
      timer: 3000,
    });
  }
}
</script>

<style scoped></style>
