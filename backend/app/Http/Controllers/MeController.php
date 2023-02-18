<?php

namespace App\Http\Controllers;

use App\Http\Resources\PetResource;
use App\Models\Pet;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class MeController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function indexPets(Request $request)
    {
        
        $pets = $request->user()->pet();
        return PetResource::collection($pets);
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  App\Http\Requests\StorePetRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function storePet(Request $request)
    {
        $data = $request->validated();
        $data["user_id"] = $request->user()->id;
        $newPet = Pet::create($data);
       // $newPet->user_id = $request->user()->id;
        return new PetResource($newPet);
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function showPet(Request $request, $id)
    {
        $pet = $request->user()->pet();
        return new PetResource($pet);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function updatePet(Request $request, $id)
    {
        $data = $request->validated();
        $pet = Pet::findOrFail($id);
        if($pet->update($data)){
            return new PetResource($pet);
        }
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy(Request $request, $id)
    {
        $pet = Pet::findOrFail($id);
        $pet->delete();
    }
}
