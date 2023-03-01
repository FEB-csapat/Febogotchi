<?php

namespace App\Http\Controllers;

use App\Http\Resources\UserResource;
use App\Models\User;
use Illuminate\Http\Request;
use App\Models\Pet;
use App\Http\Resources\PetResource;
use App\Http\Resources\PetTypeResource;
use App\Models\PetStatus;
use App\Models\PetType;
use App\Http\Resources\PetStatusResource;

class UniversalController extends Controller
{
    /**
     * Display a listing of the users.
     *
     * @return \Illuminate\Http\Response
     */
    public function indexUsers()
    {
        $users = User::all();
        return UserResource::collection($users);
    }

    /**
     * Display the specified user.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function showUser($id)
    {
        $user = User::findOrFail($id);
        return new UserResource($user);
    }

    /**
     * Display a listing of the pets.
     *
     * @return \Illuminate\Http\Response
     */
    public function indexPets()
    {
        $pets = Pet::all();
        return PetResource::collection($pets);
    }

    /**
     * Display the specified pet.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function showPet($id)
    {
        $pet = Pet::findOrFail($id);
        return new PetResource($pet);
    }

     /**
     * Display a listing of the pet types.
     *
     * @return \Illuminate\Http\Response
     */
    public function indexPetTypes()
    {
        $petTypes = PetType::all();
        return PetTypeResource::collection($petTypes);
    }

    /**
     * Display the specified pet type.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function showPetType($id)
    {
        $petType = PetType::findOrFail($id);
        return new PetTypeResource($petType);
    }


     /**
     * Display a listing of the pet types.
     *
     * @return \Illuminate\Http\Response
     */
    public function indexPetStatuses()
    {
        $petStatuses = PetStatus::all();
        return PetStatusResource::collection($petStatuses);
    }

    /**
     * Display the specified pet type.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function showPetStatus($id)
    {
        $petStatus = PetStatus::findOrFail($id);
        return new PetStatusResource($petStatus);
    }
}
