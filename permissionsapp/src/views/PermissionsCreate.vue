<template>
  <div>
    <div class="card">
      <div class="card-body">
        <h5 class="card-title">
          Create Permissions
        </h5>
      </div>
      <form style="margin:1rem" v-on:submit.prevent="onSubmit">
        <div class="form-group">
          <label for="exampleInputEmail1">Name</label>
          <input
            type="text"
            class="form-control"
            id="exampleInputEmail1"
            aria-describedby="emailHelp"
            v-model="model.name"
            required
          />
        </div>
        <div class="form-group">
          <label for="exampleInputPassword1">Last Name</label>
          <input
            type="text"
            class="form-control"
            id="exampleInputPassword1"
            v-model="model.lastName"
            required
          />
        </div>
        <div class="form-group">
          <label for="date">Date of Permission</label>
          <input
            type="date"
            class="form-control"
            id="date"
            required
            v-model="model.date"
          />
        </div>
        <div class="form-group">
          <label for="type">Type of Permission</label>
          <select
            class="form-control"
            name="type"
            id="type"
            v-model="model.typeOfPermissionId"
          >
            <option :value="type.id" v-for="type of listOfTypes" :key="type">{{
              type.description
            }}</option>
          </select>
        </div>
        <button type="submit" class="btn btn-primary float-right ml-2">
          Submit
        </button>
        <button
          type="button"
          class="btn btn-danger float-right"
          @click="$router.push('/permission')"
        >
          cancel
        </button>
      </form>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import PermissionsService from "../services/permissions.service";
import TypeOfPermissionsService from "../services/typeOfPermissions.service";
import { CreatePermissionDto } from "../models/CreatePermissionDto";
import { UpdatePermissionDto } from "../models/UpdatePermissionDto";

@Component
export default class PermissionsCreate extends Vue {
  model: CreatePermissionDto = {
    name: "",
    lastName: "",
    date: "",
    typeOfPermissionId: 0,
  };
  modelEdit: UpdatePermissionDto = {
    name: "",
    lastName: "",
    date: "",
    id: 0,
    typeOfPermissionId: 0,
  };
  listOfTypes: any[] = [];

  onSubmit() {
    console.log(this.model);
    if (this.model.id) this.update();
    else this.save();
  }

  save() {
    PermissionsService.create(this.model).then((response: any) => {
      this.$router.push("/permission");
    });
  }
  update() {
    const model = Object.assign(this.modelEdit, this.model);
    PermissionsService.update(this.modelEdit.id, this.modelEdit).then(() => {
      this.$router.push("/permission");
    });
  }

  getTypes() {
    TypeOfPermissionsService.getAll().then((r) => {
      this.listOfTypes = r["data"]["data"];
    });
  }

  getPermission(id: number) {
    PermissionsService.get(id).then((r: any) => {
      const data = r["data"]["data"];
      Object.assign(this.model, data);
      const date = new Date(this.model.date);
      this.model.date = date.toISOString().slice(0, 10);
      console.log(this.model);
    });
  }

  created() {
    if (parseInt(this.$route.params.id) > 0) {
      this.getPermission(parseInt(this.$route.params.id));
      this.getPermission(parseInt(this.$route.params.id));
    }
    this.getTypes();
  }
}
</script>

<style scoped></style>
