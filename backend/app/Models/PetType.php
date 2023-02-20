<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class PetType extends Model
{
    use HasFactory;

    protected $table = 'pet_types';
    protected $primaryKey = 'id';

    public function pet()
    {
        return $this->belongsToMany(Pet::class, "pet_type_id");
    }
}
