<?php

namespace App\Http\Controllers;

use App\Http\Resources\PetResource;
use App\Models\Pet;
use Illuminate\Http\Request;

class ActionController extends Controller
{
    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        $pet = Pet::findOrFail($id);

        $result = json_decode($request->getContent(), true);

        switch($result['action']){
            case 'hunt':
                $pet->hunt();
                break;
            case 'play':
                $pet->play();
                break;
            case 'cure':
                $pet->cure();
                break;
            case 'eat':
                $pet->eat();
                break;
            case 'sleep':
                $pet->sleep();
                break;
        }
        return new PetResource($pet);
    }
}
