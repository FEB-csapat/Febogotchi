<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Pet extends Model
{
    use HasFactory;

    protected $table = 'pets';
    protected $primaryKey = 'id';

    public function user()
    {
        return $this->belongsTo(User::class, "user_id", "pet_id");
    }

    public function petType()
    {
        return $this->hasOne(PetType::class, "pet_id");
    }
}
