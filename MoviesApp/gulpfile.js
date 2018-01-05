/// <binding BeforeBuild="copy, sass" AfterBuild="mincss" ProjectOpened="watch" />
var gulp = require('gulp'),
  sass = require('gulp-sass'),
  autoprefixer = require('gulp-autoprefixer'),
  cssmin = require('gulp-cssmin'),
  rename = require('gulp-rename');


gulp.task('copy', function () {
  gulp.src('./node_modules/bootstrap/scss/**').pipe(gulp.dest('./sass/bootstrap'));
  gulp.src('./node_modules/bootstrap/dist/js/**').pipe(gulp.dest('./wwwroot/js/dist/bootstrap'));
  gulp.src('./node_modules/jquery/dist/**').pipe(gulp.dest('./wwwroot/js/dist/jquery'));
  gulp.src('./node_modules/popper.js/dist/*.js').pipe(gulp.dest('./wwwroot/js/dist/popper'));
  gulp.src('./node_modules/font-awesome-sass/assets/stylesheets/**').pipe(gulp.dest('./sass/fa'));
  gulp.src('./node_modules/font-awesome-sass/assets/fonts/font-awesome/**').pipe(gulp.dest('./wwwroot/fonts'));
});

gulp.task('sass', function () {
  return gulp.src('./sass/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(autoprefixer({
      browsers: ['last 2 versions'],
      cascade: false
    }))
    .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('mincss', function () {
  return gulp.src('./wwwroot/css/movies.css')
    .pipe(cssmin())
    .pipe(rename({ suffix: '.min' }))
    .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('watch', function () {
  gulp.watch('./sass/*.scss', ['sass']);
});
