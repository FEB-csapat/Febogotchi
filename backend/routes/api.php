<?php


use App\Http\Controllers\UserController;
use App\Http\Controllers\PetController;
use App\Http\Controllers\PetTypeController;
use App\Http\Controllers\ActionController;
use App\Http\Controllers\RegisterController;
use App\Http\Controllers\AuthController;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/


/*
* API routes for auth
*/
//Route::get('/register', [RegisterController:: class, "create"])
//    ->name("register.create");

Route::get('/register', [RegisterController:: class, "store"])
    ->name("register.store");


Route::get('/login', [AuthController:: class, "login"])
    ->name("auth.login");

Route::post('/authenticate', [AuthController:: class, "authenticate"])
    ->name("auth.authenticate");

Route::post('/logout', [AuthController:: class, "logout"])
    ->name("auth.logout");



Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});


Route::middleware(['auth'])->group(function () {
    Route::get('/me/pets', [PetController:: class, "index"])
        ->name("pets.index");

    Route::get('/me/pets/{id}', [PetController:: class, "show"])
        ->name("pets.show");

    Route::post('/me/pets', [PetController:: class, "store"])
        ->name("pets.store");

    Route::put('/me/pets/{id}', [PetController:: class, "update"])
        ->name("pets.update");

    Route::delete('/me/pets/{id}', [PetController:: class, "destroy"])
        ->name("pets.destroy");

    Route::put('/me/pets/{id}/action', [ActionController:: class, "update"])
        ->name("action.update");
});


/*
* API routes for user
*/
Route::get('/users', [UserController:: class, "index"])
    ->name("users.index");

Route::get('/users/{id}', [UserController:: class, "show"])
    ->name("users.show");

Route::post('/users', [UserController:: class, "store"])
    ->name("users.store");

Route::put('/users/{id}', [UserController:: class, "update"])
    ->name("users.update");

Route::delete('/users/{id}', [UserController:: class, "destroy"])
    ->name("users.destroy");

/*
* API routes for pet
*/
Route::get('/pets', [PetController:: class, "index"])
    ->name("pets.index");

Route::get('/pets/{id}', [PetController:: class, "show"])
    ->name("pets.show");

Route::post('/pets', [PetController:: class, "store"])
    ->name("pets.store");

Route::put('/pets/{id}', [PetController:: class, "update"])
    ->name("pets.update");

Route::delete('/pets/{id}', [PetController:: class, "destroy"])
    ->name("pets.destroy");

/*
* API routes for pet type
*/
Route::get('/pet_types', [PetTypeController:: class, "index"])
    ->name("pet_types.index");

Route::get('/pet_types/{id}', [PetTypeController:: class, "show"])
    ->name("pet_types.show");


/*
* API routes for pet action
*/
Route::put('/pets/{id}/action', [ActionController:: class, "update"])
->name("action.update");

