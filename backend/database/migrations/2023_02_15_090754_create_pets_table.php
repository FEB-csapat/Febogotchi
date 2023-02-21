<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;
use Illuminate\Support\Carbon;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('pets', function (Blueprint $table) {
            $table->id();
            $table->foreignId('user_id');
            $table->foreignId('pet_type_id');

            $table->string('name');
            $table->integer('age')->default('0');

            $table->enum('status', ["idle", "hunt", "play", "cure", "eat", "sleep"]);
            
            $table->integer('happiness')->default('5');
            $table->integer('wellbeing')->default('5');
            $table->integer('fittness')->default('5');
            $table->integer('sate')->default('5');
            $table->integer('energy')->default('5');

            $table->boolean('is_alive')->default(true);

            $table->date('birth_date')->default(Carbon::now());
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('pets');
    }
};
