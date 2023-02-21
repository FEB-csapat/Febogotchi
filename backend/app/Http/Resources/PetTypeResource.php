<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class PetTypeResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
        return [
            'id' => $this->id,
           // 'pet' => (new PetResource($this->whenLoaded('pet')))
            'type' => $this->type
          //  'created_at' => $this->created_at,
          //  'updated_at' => $this->updated_at
        ];
    }
}
