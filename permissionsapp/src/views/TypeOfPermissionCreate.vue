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
          <label for="exampleInputEmail1">Description</label>
          <input
            type="text"
            class="form-control"
            id="exampleInputEmail1"
            aria-describedby="emailHelp"
            v-model="model.description"
            required
          />
        </div>
        <button type="submit" class="btn btn-primary float-right ml-2">
          Submit
        </button>
        <button
          type="button"
          class="btn btn-danger float-right"
          @click="$router.push('/typeofpermission')"
        >
          cancel
        </button>
      </form>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import TypeOfPermissionsService from "../services/typeOfPermissions.service";
import { CreateTypeOfPermissionDto } from "../models/CreateTypeOfPermissionDto";
import { UpdateTypeOfPermission } from "../models/UpdateTypeOfPermission";

@Component
export default class TypeOfPermissionCreate extends Vue {
  model: CreateTypeOfPermissionDto = {
    description: "",
  };
  modelEdit: UpdateTypeOfPermission = {
    description: "",
    id: 0,
  };
  listOfTypes: any[] = [];

  onSubmit() {
    console.log(this.model);
    if (this.model.id) this.update();
    else this.save();
  }

  save() {
    TypeOfPermissionsService.create(this.model).then((response: any) => {
      this.$router.push("/typeofpermission");
    });
  }
  update() {
    const model = Object.assign(this.modelEdit, this.model);
    TypeOfPermissionsService.update(this.modelEdit.id, this.modelEdit).then(
      () => {
        this.$router.push("/typeofpermission");
      }
    );
  }

  getTypes() {
    TypeOfPermissionsService.getAll().then((r) => {
      this.listOfTypes = r["data"]["data"];
    });
  }

  getPermission(id: number) {
    TypeOfPermissionsService.get(id).then((r: any) => {
      const data = r["data"]["data"];
      Object.assign(this.model, data);
      console.log(this.model);
    });
  }

  created() {
    if (parseInt(this.$route.params.id) > 0) {
      this.getPermission(parseInt(this.$route.params.id));
    }
    this.getTypes();
  }
}
</script>

<style scoped></style>
