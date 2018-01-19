<template>
	<div>
		<div class="row">
			<div class="col mt-3">
				<button class="btn btn-primary" v-on:click="openAddModal">Add Movie</button>
			</div>
		</div>
		<div class="row">
			<movie v-on:delete-movie="deleteMovie" v-on:edit-movie="editMovie" v-for="movie in movies" v-bind:movie="movie"></movie>
			<add-movie v-if="showAddModal" v-bind:movie="movieToAdd" v-on:close-add-modal="closeAddModal" v-on:save-movie-add="saveMovieAdd"></add-movie>
			<edit-movie v-if="showEditModal" v-bind:movie="movieToEdit" v-on:close-edit-modal="closeEditModal" v-on:save-movie-edit="saveMovieEdit"></edit-movie>
		</div>
	</div>
</template>
<script>
	import Movie from './components/Movie'
	import AddMovie from './components/AddMovie'
	import EditMovie from './components/EditMovie'
	import axios from 'axios'
	export default {
		name: 'app',
		components: {
			Movie,
			AddMovie,
			EditMovie
		},
		data() {
			return {
				movies: []
				movieToEdit: {
					title: '',
					year: '',
					director: '',
					description: ''
				},
				editMovieIndex: 0,
				showEditModal: false,
				movieToAdd: {
					title: '',
					year: '',
					director: '',
					description: ''
				},
				showAddModal: false
			};
		},
		mounted() {
			this.getMovies();
		},
		methods: {
			getMovies() {
				axios({
					method: 'GET', 'url': '/api/movies'
				}).then(result => {
					this.movies = result.data;
				}, error => {
					console.error(error);
				});
			},
			deleteMovie(id) {
				axios({
					method: 'DELETE', 'url': '/api/movies/' + id
				}).then(result => {
					this.getMovies();
				}, error => {
					console.error(error);
				});
			},
			editMovie(id) {
				axios({
					method: 'GET', 'url': '/api/movies/' + id
				}).then(result => {
					this.movieToEdit = result.data;
				}, error => {
					console.error(error);
				});
				this.showEditModal = true;
			},
			closeEditModal() {
				this.showEditModal = false;
				this.movieToEdit = {
					title: '',
					year: '',
					director: '',
					description: ''
				};
			},
			saveMovieEdit() {
				axios({
					method: 'PUT', 'url': '/api/movies/' + this.movieToEdit.id, 'data': this.movieToEdit
				}).then(result => {
					this.getMovies();
				}, error => {
					console.error(error);
				});
				this.closeEditModal();
			},
			openAddModal() {
				this.showAddModal = true;
			},
			closeAddModal() {
				this.showAddModal = false;
				this.movieToAdd = {
					title: '',
					year: '',
					director: '',
					description: ''
				};
			},
			saveMovieAdd() {
				axios({
					method: 'POST', 'url': '/api/movies', 'data': this.movieToAdd
				}).then(result => {
					this.getMovies();
				}, error => {
					console.error(error);
				});
			},
		},
	}
</script>
<style lang="scss">
</style>
