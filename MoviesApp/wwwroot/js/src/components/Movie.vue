<template>
  <div class="col-sm-4">
    <div class="card mt-3">
      <!--<img src="http://placehold.it/544x800/" alt="Movie Poster" class="card-img-top" />-->
      <div class="card-body" v-show="!isEditing">
        <h4 class="card-title">{{movie.title}}</h4>
        <h6 class="card-subtitle mb-2 text-muted">{{movie.year}} - {{movie.director}}</h6>
        <p class="card-text">
          {{movie.description}}
        </p>
        <button class="btn btn-primary" v-on:click="showForm">Edit</button>
        <button class="btn btn-secondary" v-on:click="deleteMovie(movie)">Delete</button>
      </div>
      <div class="card-body" v-show="isEditing">
        <h4 class="card-title">Edit</h4>
        <div class="form-group">
          <label>Title</label>
          <input type="text" class="form-control" v-model="movie.title" />
        </div>
        <div class="form-group">
          <label>Year</label>
          <input type="text" class="form-control" v-model="movie.year" />
        </div>
        <div class="form-group">
          <label>Director</label>
          <input type="text" class="form-control" v-model="movie.director" />
        </div>
        <div class="form-group">
          <label>Description</label>
          <textarea class="form-control" rows="3" v-model="movie.description"></textarea>
        </div>
        <button class="btn btn-primary" v-on:click="hideForm">Submit</button>
      </div>
    </div>
  </div>
</template>
<script type="text/javascript">
  export default {
    props: ['movie'],
    data() {
      return {
        isEditing: false,
      };
    },
    methods: {
      showForm() {
        this.isEditing = true;
      },
      hideForm() {
        this.isEditing = false;
      },
      deleteMovie(movie) {
        this.$emit('delete-movie', movie);
      },
    },
  };
</script>
<style lang="scss"></style>
