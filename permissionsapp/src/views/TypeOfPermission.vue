<template>
  <div>
    <div class="card">
      <div class="card-body">
        <h5 class="card-title">
          List of type of permissions
          <button
            @click="$router.push('/typeofpermission/create/0')"
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
              <th scope="col">Description</th>
              <th>Options</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in list" :key="item.id">
              <th scope="row">{{ index + 1 }}</th>
              <td>{{ item.description }}</td>
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
import { TypeOfPermissionDto } from "../models/TypeOfPermissionDto";
import TypeOfPermissionsService from "../services/typeOfPermissions.service";

@Component
export default class TypeOfPermission extends Vue {
  list: TypeOfPermissionDto[] = [];

  init() {
    TypeOfPermissionsService.getAll().then((r: any) => {
      this.list = r["data"]["data"];
    });
  }

  goToEditPage(id: number) {
    this.$router.push(`/typeofpermission/create/${id}`);
  }

  created() {
    this.init();
  }

  remove(id: number) {
    this.question(() => {
      TypeOfPermissionsService.delete(id).then(() => {
        this.success("Success").then(() => this.init());
      });
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
