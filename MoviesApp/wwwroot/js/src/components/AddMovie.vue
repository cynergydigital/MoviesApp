<template>
  <div class="col-sm-4">
    <div class="card mt-3">
      <div class="card-body" v-show="!isCreating">
        <button class="btn btn-primary" v-on:click="openForm">Add Movie</button>
      </div>
      <div class="card-body" v-show="isCreating">
        <h4 class="card-title">Add</h4>
        <div class="form-group">
          <label>Title</label>
          <input type="text" class="form-control" v-model="titleText" />
        </div>
        <div class="form-group">
          <label>Year</label>
          <input type="text" class="form-control" v-model="yearText" />
        </div>
        <div class="form-group">
          <label>Director</label>
          <input type="text" class="form-control" v-model="directorText" />
        </div>
        <div class="form-group">
          <label>Description</label>
          <textarea class="form-control" rows="3" v-model="descriptionText"></textarea>
        </div>
        <button class="btn btn-primary" v-on:click="sendForm()">Submit</button>
        <button class="btn btn-secondary" v-on:click="closeForm">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        titleText: '',
        yearText: '',
        directorText: '',
        descriptionText: '',
        isCreating: false,
      };
    },
    methods: {
      openForm() {
        this.isCreating = true;
      },
      closeForm() {
        this.isCreating = false;
      },
      sendForm() {
        if (this.titleText.length > 0 && this.yearText.length > 0 && this.directorText.length > 0 && this.descriptionText.length > 0) {
          const title = this.titleText;
          const year = this.yearText;
          const director = this.directorText;
          const description = this.descriptionText;
          this.$emit('add-movie', {
            title,
            year,
            director,
            description,
          });
          this.titleText = '';
          this.yearText = '';
          this.directorText = '';
          this.descriptionText = '';
        }
        this.isCreating = false;
      },
    },
  };
</script>

<style></style>	
