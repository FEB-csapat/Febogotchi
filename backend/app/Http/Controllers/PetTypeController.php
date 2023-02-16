<?php

namespace App\Http\Controllers;

use App\Http\Resources\PetTypeResource;
use App\Models\PetType;
use Illuminate\Http\Request;

class PetTypeController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $petTypes = PetType::all();
        return PetTypeResource::collection($petTypes);
    }


    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        $user = PetType::findOrFail($id);
        return new PetTypeResource($user);
    }

}
